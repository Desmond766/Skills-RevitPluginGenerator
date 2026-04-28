---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarBendingDetail.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,System.Int32,Autodesk.Revit.DB.Structure.RebarBendingDetailType,Autodesk.Revit.DB.XYZ,System.Double)
zh: 创建、新建、生成、建立、新增
source: html/2158ccdb-1b50-ec9b-7bef-130450aea0d9.htm
---
# Autodesk.Revit.DB.Structure.RebarBendingDetail.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a bending detail.

## Syntax (C#)
```csharp
public static Element Create(
	Document document,
	ElementId viewId,
	ElementId reinforcementElementId,
	int reinforcementElementSubelementKey,
	RebarBendingDetailType bendingDetailType,
	XYZ position,
	double rotation
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document to which the new element should be added.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The id of the view in which the new element should be added.
- **reinforcementElementId** (`Autodesk.Revit.DB.ElementId`) - The reinforcement element Id that this object will represent.
- **reinforcementElementSubelementKey** (`System.Int32`) - The index of the sub-element from the reinforcement element that this object will represent.
- **bendingDetailType** (`Autodesk.Revit.DB.Structure.RebarBendingDetailType`) - The bending details type used with the resulting object.
- **position** (`Autodesk.Revit.DB.XYZ`) - The initial position in the view where this object will be created.
- **rotation** (`System.Double`) - The initial rotation in the view for this element.

## Returns
Returns an instance of a bending detail.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

