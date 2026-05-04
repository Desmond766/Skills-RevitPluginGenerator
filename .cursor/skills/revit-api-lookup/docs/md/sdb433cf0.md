---
kind: method
id: M:Autodesk.Revit.DB.Subelement.GetGeometryObject(Autodesk.Revit.DB.View)
source: html/be23471b-e6ba-472f-f960-06d7e3dce56a.htm
---
# Autodesk.Revit.DB.Subelement.GetGeometryObject Method

Retrieve one geometric primitive representing given subelement.

## Syntax (C#)
```csharp
public GeometryObject GetGeometryObject(
	View dbView
)
```

## Parameters
- **dbView** (`Autodesk.Revit.DB.View`) - The view for view-specific geometry or Nothing nullptr a null reference ( Nothing in Visual Basic) for model geometry.

## Returns
The geometric object representing this subelement.

## Remarks
In case of whole element, geometric object representing element and its subelements will be returned.
 Nothing nullptr a null reference ( Nothing in Visual Basic) will be returned if related geometric object could not be found in the model.

