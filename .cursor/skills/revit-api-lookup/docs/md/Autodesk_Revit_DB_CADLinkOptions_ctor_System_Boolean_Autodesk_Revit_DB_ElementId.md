---
kind: method
id: M:Autodesk.Revit.DB.CADLinkOptions.#ctor(System.Boolean,Autodesk.Revit.DB.ElementId)
source: html/c458ad62-a592-ce16-b8b9-645ac1d97f44.htm
---
# Autodesk.Revit.DB.CADLinkOptions.#ctor Method

Creates a CADLinkOptions object, specifying whether to preserve
 graphic overrides, and what view to use if the link's view has been
 deleted.

## Syntax (C#)
```csharp
public CADLinkOptions(
	bool preserveOverrides,
	ElementId viewId
)
```

## Parameters
- **preserveOverrides** (`System.Boolean`) - True if Revit should preserve the link's graphic overrides on reload.
 False otherwise.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The id of the view to use as the link's reference view, if the reference
 view has been deleted. Revit will ignore this value if the reference
 view is still in place. The value may be ElementId.InvalidElementId, although Revit will
 cancel the load if the reference view is deleted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

