---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewPointBoundaryConditions(Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Structure.TranslationRotationValue,System.Double,Autodesk.Revit.DB.Structure.TranslationRotationValue,System.Double,Autodesk.Revit.DB.Structure.TranslationRotationValue,System.Double,Autodesk.Revit.DB.Structure.TranslationRotationValue,System.Double,Autodesk.Revit.DB.Structure.TranslationRotationValue,System.Double,Autodesk.Revit.DB.Structure.TranslationRotationValue,System.Double)
zh: 文档、文件
source: html/db4e68f0-d06c-8207-98fb-83e84b3cb2d1.htm
---
# Autodesk.Revit.Creation.Document.NewPointBoundaryConditions Method

**中文**: 文档、文件

Creates a new Point BoundaryConditions Element.

## Syntax (C#)
```csharp
public BoundaryConditions NewPointBoundaryConditions(
	Reference reference,
	TranslationRotationValue X_Translation,
	double X_TranslationSpringModulus,
	TranslationRotationValue Y_Translation,
	double Y_TranslationSpringModulus,
	TranslationRotationValue Z_Translation,
	double Z_TranslationSpringModulus,
	TranslationRotationValue X_Rotation,
	double X_RotationSpringModulus,
	TranslationRotationValue Y_Rotation,
	double Y_RotationSpringModulus,
	TranslationRotationValue Z_Rotation,
	double Z_RotationSpringModulus
)
```

## Parameters
- **reference** (`Autodesk.Revit.DB.Reference`) - A Geometry reference to a Beam's, Brace's or Column's analytical line end.
- **X_Translation** (`Autodesk.Revit.DB.Structure.TranslationRotationValue`) - A value indicating the X axis translation option.
- **X_TranslationSpringModulus** (`System.Double`) - Translation Spring Modulus for X axis. Ignored if X_Translation is not "Spring".
- **Y_Translation** (`Autodesk.Revit.DB.Structure.TranslationRotationValue`) - A value indicating the Y axis translation option.
- **Y_TranslationSpringModulus** (`System.Double`) - Translation Spring Modulus for Y axis. Ignored if Y_Translation is not "Spring".
- **Z_Translation** (`Autodesk.Revit.DB.Structure.TranslationRotationValue`) - A value indicating the Z axis translation option.
- **Z_TranslationSpringModulus** (`System.Double`) - Translation Spring Modulus for Z axis. Ignored if Z_Translation is not "Spring".
- **X_Rotation** (`Autodesk.Revit.DB.Structure.TranslationRotationValue`) - A value indicating the option for rotation about the X axis.
- **X_RotationSpringModulus** (`System.Double`) - Rotation Spring Modulus for X axis. Ignored if X_Rotation is not "Spring".
- **Y_Rotation** (`Autodesk.Revit.DB.Structure.TranslationRotationValue`) - A value indicating the option for rotation about the Y axis.
- **Y_RotationSpringModulus** (`System.Double`) - Rotation Spring Modulus for Y axis. Ignored if Y_Rotation is not "Spring".
- **Z_Rotation** (`Autodesk.Revit.DB.Structure.TranslationRotationValue`) - A value indicating the option for rotation about the Z axis.
- **Z_RotationSpringModulus** (`System.Double`) - Rotation Spring Modulus for Z axis. Ignored if Y_Rotation is not "Spring".

## Returns
If successful, NewPointBoundaryConditions returns an object for the newly created BoundaryConditions
with the BoundaryType = 0 - "Point". Nothing nullptr a null reference ( Nothing in Visual Basic) is returned if the operation fails.

## Remarks
This method will only function with the Autodesk Revit Structure application.

