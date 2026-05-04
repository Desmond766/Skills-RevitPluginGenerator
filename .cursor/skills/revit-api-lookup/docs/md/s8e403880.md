---
kind: method
id: M:Autodesk.Revit.DB.CylindricalHelix.Create(Autodesk.Revit.DB.XYZ,System.Double,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,System.Double,System.Double,System.Double)
zh: 创建、新建、生成、建立、新增
source: html/851cb6a7-fcc3-a518-78ae-98c43c728b1b.htm
---
# Autodesk.Revit.DB.CylindricalHelix.Create Method

**中文**: 创建、新建、生成、建立、新增

Create a cylindrical helix.

## Syntax (C#)
```csharp
public static CylindricalHelix Create(
	XYZ basePoint,
	double radius,
	XYZ xVector,
	XYZ zVector,
	double pitch,
	double startAngle,
	double endAngle
)
```

## Parameters
- **basePoint** (`Autodesk.Revit.DB.XYZ`) - Base point of the axis. It can be any point in 3d.
- **radius** (`System.Double`) - Radius. It should be a positive number.
- **xVector** (`Autodesk.Revit.DB.XYZ`) - X vector. Should be Non-zero vector.
- **zVector** (`Autodesk.Revit.DB.XYZ`) - Z vector = axis direction. Should be non-zero and orthogonal to X Vector.
- **pitch** (`System.Double`) - Pitch. It should be non-zero number, can be positive or negative.
 Positive means right handed and negative means left handed.
- **startAngle** (`System.Double`) - Start angle. It specifies the start point of the Helix.
- **endAngle** (`System.Double`) - End angle. It specifies the end point of the Helix. 
 End angle should not be equal to start angle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The radius is negative -or- 
 the pitch is zero -or-
 the xVector or zVector is zero length -or- 
 zVector is not orthogonal to xVector -or- 
 endAngle is equal to startAngle.

