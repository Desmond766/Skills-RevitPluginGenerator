# Revit API Recipes

Condensed, copy-ready snippets for common add-in tasks. Each is known to compile against Revit 2024.

## Selection

### Get currently selected elements

```csharp
ICollection<ElementId> ids = uiDoc.Selection.GetElementIds();
IList<Element> elems = ids.Select(id => doc.GetElement(id)).ToList();
```

### Prompt user to pick elements of a category

```csharp
IList<Reference> refs = uiDoc.Selection.PickObjects(
    ObjectType.Element,
    new CategoryFilter(BuiltInCategory.OST_Walls),
    "Select walls");
```

Where `CategoryFilter` is a small `ISelectionFilter` that returns true for the category.

### Simple ISelectionFilter

```csharp
public class CategoryFilter : ISelectionFilter
{
    private readonly BuiltInCategory _bic;
    public CategoryFilter(BuiltInCategory bic) { _bic = bic; }
    public bool AllowElement(Element e) => e?.Category?.Id.IntegerValue == (int)_bic;
    public bool AllowReference(Reference r, XYZ p) => true;
}
```

## Collecting elements

### All instances of a category in the active view

```csharp
var walls = new FilteredElementCollector(doc, doc.ActiveView.Id)
    .OfCategory(BuiltInCategory.OST_Walls)
    .WhereElementIsNotElementType()
    .Cast<Wall>()
    .ToList();
```

### All types (symbols) of a category in the project

```csharp
var wallTypes = new FilteredElementCollector(doc)
    .OfCategory(BuiltInCategory.OST_Walls)
    .WhereElementIsElementType()
    .Cast<WallType>()
    .ToList();
```

### Family instances of a specific family/type

```csharp
var collector = new FilteredElementCollector(doc)
    .OfClass(typeof(FamilyInstance))
    .Cast<FamilyInstance>()
    .Where(fi => fi.Symbol.Family.Name == "MyFamily");
```

## Parameters

### Read a built-in parameter

```csharp
Parameter p = wall.get_Parameter(BuiltInParameter.HOST_AREA_COMPUTED);
double area = p?.AsDouble() ?? 0.0; // square feet (internal)
```

### Write a shared or project parameter by name

```csharp
Parameter p = element.LookupParameter("MyParam");
if (p != null && !p.IsReadOnly) p.Set("new value");
```

### Unit conversion

```csharp
// Revit stores lengths in feet, areas in sq ft, volumes in cu ft.
double lengthMm = UnitUtils.ConvertFromInternalUnits(lengthFt, UnitTypeId.Millimeters);
double feet    = UnitUtils.ConvertToInternalUnits(500, UnitTypeId.Millimeters);
```

## Transactions

### Single transaction

```csharp
using (Transaction tx = new Transaction(doc, "My change"))
{
    tx.Start();
    // mutate doc...
    tx.Commit();
}
```

### Grouped transactions (assimilate for a single undo entry)

```csharp
using (TransactionGroup tg = new TransactionGroup(doc, "Batch op"))
{
    tg.Start();
    foreach (var item in items)
    {
        using (Transaction tx = new Transaction(doc, "step"))
        {
            tx.Start();
            // mutate doc...
            tx.Commit();
        }
    }
    tg.Assimilate();
}
```

### Suppress warnings

```csharp
public class HideWarnings : IFailuresPreprocessor
{
    public FailureProcessingResult PreprocessFailures(FailuresAccessor a)
    {
        foreach (var f in a.GetFailureMessages())
            if (f.GetSeverity() == FailureSeverity.Warning)
                a.DeleteWarning(f);
        return FailureProcessingResult.Continue;
    }
}

var opts = tx.GetFailureHandlingOptions();
opts.SetFailuresPreprocessor(new HideWarnings());
tx.SetFailureHandlingOptions(opts);
```

## Geometry

### Location point / curve

```csharp
if (wall.Location is LocationCurve lc)
{
    Curve c = lc.Curve;        // bound curve in world coords
    XYZ start = c.GetEndPoint(0);
    XYZ end   = c.GetEndPoint(1);
}
```

### Bounding box

```csharp
BoundingBoxXYZ bb = element.get_BoundingBox(null); // null = model coords
XYZ min = bb.Min, max = bb.Max;
```

## UI

### TaskDialog

```csharp
TaskDialog.Show("Title", $"Processed {count} elements.");
```

### Modeless WPF window (requires ExternalEvent for doc access)

Use `ExternalEvent` + `IExternalEventHandler` when a WPF window needs to mutate the document. Never touch `Document` from a non-Revit thread.

## Ribbon (inside `IExternalApplication.OnStartup`)

```csharp
application.CreateRibbonTab("ACME");
RibbonPanel panel = application.CreateRibbonPanel("ACME", "Utilities");
PushButtonData btn = new PushButtonData(
    "btnRename", "Rename\nWalls",
    Assembly.GetExecutingAssembly().Location,
    "RevitAddins.WallRenamer.RenameWallsCommand");
panel.AddItem(btn);
```

## Learning from packaged plug-in references

The skill ships with a packaged catalog generated from existing plug-ins:
`.cursor/skills/revit-addin-scaffold/samples-index/INDEX.md`. Normal users do **not** need the full `existingCodes/` tree. **Always search the packaged index first**:

```powershell
rg -i "<keyword>" .cursor\skills\revit-addin-scaffold\samples-index\INDEX.md -A 7
```

INDEX.md entries carry the author's own Action/Dialog labels (often Chinese), BuiltInCategories, BuiltInParameters, APIs, UI framework, integrations, bilingual tags, and a `Snippet:` path. Most requests can be matched from INDEX.md plus the compact snippet without reading full source.

When an entry has a strong match, read its `Snippet:` markdown under `samples-index/snippets/` to borrow structure and API usage. Only search full source directly in a maintainer workspace that actually has `existingCodes/`, or when the user explicitly asks to migrate a complete old project:

```powershell
# Selection / filter helpers
rg -l -i "ISelectionFilter" existingCodes --glob *.cs

# Transaction wrappers
rg -l -i "class.*Transaction|TransactionManager" existingCodes --glob *.cs

# Excel export patterns
rg -l -i "Microsoft\.Office\.Interop\.Excel" existingCodes --glob *.cs

# Modeless WPF/WinForms via ExternalEvent
rg -l -i "IExternalEventHandler|ExternalEvent\.Create" existingCodes --glob *.cs
```

Commonly reusable files across projects: `Utils.cs`, `UIRibbon.cs`, `ErrorCollector.cs`, `RelatedDataFiller.cs`, `MyEventHandler.cs`.

Most existing projects use **WinForms** (`.Designer.cs` + `.resx`) for dialogs. Match this style unless the user explicitly wants WPF — the INDEX.md `UI:` field tells you at a glance.
