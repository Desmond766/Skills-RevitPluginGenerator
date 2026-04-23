# Revit 2024 API Cheatsheet

The high-frequency APIs. Use this before grepping `./docs/`.

## Entry points

| Type | Interface | Attribute |
|---|---|---|
| Command | `IExternalCommand` | `[Transaction(TransactionMode.Manual)]` + `[Regeneration(RegenerationOption.Manual)]` |
| Application | `IExternalApplication` | *(none)* |
| Event handler (modeless) | `IExternalEventHandler` | *(none — registered via `ExternalEvent.Create`)* |

Command entry signature:

```csharp
public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements);
```

From `commandData`:
- `UIApplication uiApp = commandData.Application;`
- `UIDocument uiDoc = uiApp.ActiveUIDocument;`
- `Document doc = uiDoc.Document;`

## Collectors

```csharp
// Instances of a category, in active view:
new FilteredElementCollector(doc, doc.ActiveView.Id)
    .OfCategory(BuiltInCategory.OST_Walls)
    .WhereElementIsNotElementType();

// Types (symbols) project-wide:
new FilteredElementCollector(doc)
    .OfClass(typeof(FamilySymbol))
    .WhereElementIsElementType();

// Logical AND / OR:
new FilteredElementCollector(doc)
    .WherePasses(new LogicalAndFilter(filterA, filterB));
```

Common filters: `ElementCategoryFilter`, `ElementClassFilter`, `ElementLevelFilter`, `ElementParameterFilter`, `BoundingBoxIntersectsFilter`, `FamilyInstanceFilter`.

## Transactions

```csharp
using (var tx = new Transaction(doc, "name"))
{
    tx.Start();
    // mutations
    tx.Commit();
}

// Multiple steps as one undo entry:
using (var tg = new TransactionGroup(doc, "batch"))
{
    tg.Start();
    // ... transactions inside ...
    tg.Assimilate();
}

// Readonly parallel state, rollback on exit:
using (var sub = new SubTransaction(doc)) { sub.Start(); /*...*/ sub.RollBack(); }
```

Never mutate outside a transaction. Never commit from a non-Revit thread.

## Selection

```csharp
ICollection<ElementId> ids = uiDoc.Selection.GetElementIds();
uiDoc.Selection.SetElementIds(new[] { id }.ToList());

Reference r = uiDoc.Selection.PickObject(ObjectType.Element, "Select one");
IList<Reference> rs = uiDoc.Selection.PickObjects(ObjectType.Element, filter, "Pick many");
XYZ p = uiDoc.Selection.PickPoint("Pick a point");
```

## Parameters

```csharp
Parameter p = elem.get_Parameter(BuiltInParameter.XXX);  // built-in (preferred)
Parameter p = elem.LookupParameter("Comments");          // by name (slower, locale-sensitive)

double  d = p.AsDouble();    // internal units
int     i = p.AsInteger();
string  s = p.AsString();
ElementId id = p.AsElementId();

if (!p.IsReadOnly) p.Set(value);
```

Frequently used built-ins: `HOST_AREA_COMPUTED`, `HOST_VOLUME_COMPUTED`, `CURVE_ELEM_LENGTH`, `ALL_MODEL_INSTANCE_COMMENTS`, `SYMBOL_NAME_PARAM`, `ELEM_FAMILY_AND_TYPE_PARAM`, `LEVEL_NAME`, `WALL_BASE_CONSTRAINT`, `WALL_BASE_OFFSET`.

## Units (Revit 2022+ API)

```csharp
double mm = UnitUtils.ConvertFromInternalUnits(lenFt, UnitTypeId.Millimeters);
double ft = UnitUtils.ConvertToInternalUnits(500, UnitTypeId.Millimeters);
```

`UnitTypeId` members: `Millimeters`, `Centimeters`, `Meters`, `Feet`, `Inches`, `SquareMeters`, `CubicMeters`, `Degrees`, `Radians`, etc.

## Geometry basics

```csharp
// Location
if (elem.Location is LocationPoint lp) { XYZ pt = lp.Point; }
if (elem.Location is LocationCurve lc) { Curve c = lc.Curve; }

// BoundingBox
BoundingBoxXYZ bb = elem.get_BoundingBox(view: null); // null = model

// Geometry
Options opts = new Options { ComputeReferences = true, DetailLevel = ViewDetailLevel.Fine };
GeometryElement ge = elem.get_Geometry(opts);
foreach (GeometryObject g in ge) { /* Solid, Curve, Mesh, GeometryInstance ... */ }

// Transforms
XYZ moved = Transform.CreateTranslation(new XYZ(1,0,0)).OfPoint(pt);
```

## Element creation (must be inside a Transaction)

```csharp
Wall w = Wall.Create(doc, curve, levelId, structural: false);

FamilyInstance fi = doc.Create.NewFamilyInstance(
    location: new XYZ(0,0,0),
    symbol: symbol,
    level: level,
    structuralType: StructuralType.NonStructural);

// Copy / Move / Rotate
ElementTransformUtils.MoveElement(doc, elem.Id, new XYZ(1,0,0));
ICollection<ElementId> copies = ElementTransformUtils.CopyElement(doc, elem.Id, new XYZ(2,0,0));
ElementTransformUtils.RotateElement(doc, elem.Id, axis, angleRadians);
```

## Task dialog & prompts

```csharp
TaskDialog.Show("Title", "Body text");

var td = new TaskDialog("Confirm") { MainContent = "Proceed?", CommonButtons = TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No };
if (td.Show() != TaskDialogResult.Yes) return Result.Cancelled;
```

## Events (subscribe in `IExternalApplication.OnStartup`)

Common: `DocumentOpened`, `DocumentChanged`, `ViewActivated`, `DocumentSaving`, `Idling`. Always unsubscribe in `OnShutdown`.

## Modeless UI — `ExternalEvent`

From a WPF button outside Revit's main loop, you can't touch `Document` directly. Wrap the work in `IExternalEventHandler`:

```csharp
public class MyHandler : IExternalEventHandler
{
    public Action<UIApplication> Work;
    public void Execute(UIApplication app) => Work?.Invoke(app);
    public string GetName() => "MyHandler";
}

// at startup:
var handler = new MyHandler();
ExternalEvent evt = ExternalEvent.Create(handler);

// from WPF:
handler.Work = a => { /* safe doc access here */ };
evt.Raise();
```

## Common pitfalls

- Revit stores lengths in **decimal feet**, areas in **sq ft**, volumes in **cu ft**, angles in **radians**.
- `ElementId` equality: use `.IntegerValue` when keying in dictionaries across contexts.
- `Dispose()` `Options`, `Transaction`, `FilteredElementCollector`; don't dispose `Document`, `Element`, `Parameter`.
- Pass `doc.ActiveView.Id` to the collector for view-based queries (respects crop + visibility). Omit it for project-wide queries.
- `FamilySymbol.Activate()` must be called before placing an instance of an inactive symbol.
