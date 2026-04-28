---
kind: method
id: M:Autodesk.Revit.DB.Architecture.TopographyEditScope.Start(Autodesk.Revit.DB.ElementId)
source: html/e4135df3-65e9-0bda-bb64-e76d559838b0.htm
---
# Autodesk.Revit.DB.Architecture.TopographyEditScope.Start Method

Starts a topography surface edit mode for an existing TopographySurface element.

## Syntax (C#)
```csharp
public ElementId Start(
	ElementId topoSurfaceId
)
```

## Parameters
- **topoSurfaceId** (`Autodesk.Revit.DB.ElementId`) - The TopographySurface element to be edited.

## Returns
The Id of the topography Surface being edited.

## Remarks
The application will need to start a transaction to actually make changes to the TopographySurface element.
 TopographyEditScope can only be started when there is no transaction active, thus it does not
 work for commands running in automatic transaction mode.
 Like all Start methods in any edit scope object this too returns an Id of the element in the edit session,
 even though in this case here it always equals to the given topoSurfaceId.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId topoSurfaceId does not represent a TopographySurface.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This TopographyEditScope is not permitted to start at this moment for one of the following possible reasons:
 The document is in read-only state, or the document is currently modifiable,
 or there already is another edit mode active in the document.

