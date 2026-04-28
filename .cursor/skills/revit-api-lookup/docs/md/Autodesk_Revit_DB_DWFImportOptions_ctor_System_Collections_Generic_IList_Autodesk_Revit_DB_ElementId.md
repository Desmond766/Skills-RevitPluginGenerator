---
kind: method
id: M:Autodesk.Revit.DB.DWFImportOptions.#ctor(System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId})
source: html/d338d421-9187-0add-9a6e-04de0bdd4ecf.htm
---
# Autodesk.Revit.DB.DWFImportOptions.#ctor Method

Constructs a new instance of DWFImportOptions with an array of imported sheet views.

## Syntax (C#)
```csharp
public DWFImportOptions(
	IList<ElementId> views
)
```

## Parameters
- **views** (`System.Collections.Generic.IList < ElementId >`) - These sheet views where DWF markups are imported.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

