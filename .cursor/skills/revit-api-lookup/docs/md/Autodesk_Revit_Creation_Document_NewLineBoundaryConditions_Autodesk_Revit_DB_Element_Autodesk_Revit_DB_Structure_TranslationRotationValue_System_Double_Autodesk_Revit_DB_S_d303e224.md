---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewLineBoundaryConditions(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Structure.TranslationRotationValue,System.Double,Autodesk.Revit.DB.Structure.TranslationRotationValue,System.Double,Autodesk.Revit.DB.Structure.TranslationRotationValue,System.Double,Autodesk.Revit.DB.Structure.TranslationRotationValue,System.Double)
zh: 文档、文件
source: html/763b3890-cac4-32c6-69c6-e4ebe6cfdd6e.htm
---
# Autodesk.Revit.Creation.Document.NewLineBoundaryConditions Method

**中文**: 文档、文件

Creates a new Line BoundaryConditions element on a host element.

## Syntax (C#)
```csharp
public BoundaryConditions NewLineBoundaryConditions(
	Element hostElement,
	TranslationRotationValue X_Translation,
	double X_TranslationSpringModulus,
	TranslationRotationValue Y_Translation,
	double Y_TranslationSpringModulus,
	TranslationRotationValue Z_Translation,
	double Z_TranslationSpringModulus,
	TranslationRotationValue X_Rotation,
	double X_RotationSpringModulus
)
```

## Parameters
- **hostElement** (`Autodesk.Revit.DB.Element`) - A Beam.
- **X_Translation** (`Autodesk.Revit.DB.Structure.TranslationRotationValue`) - A value indicating the X axis translation option.
- **X_TranslationSpringModulus** (`System.Double`) - Translation Spring Modulus for X axis. Ignored if X_Translation is not "Spring".
- **Y_Translation** (`Autodesk.Revit.DB.Structure.TranslationRotationValue`) - A value indicating the Y axis translation option.
- **Y_TranslationSpringModulus** (`System.Double`) - Translation Spring Modulus for Y axis. Ignored if Y_Translation is not "Spring".
- **Z_Translation** (`Autodesk.Revit.DB.Structure.TranslationRotationValue`) - A value indicating the Z axis translation option.
- **Z_TranslationSpringModulus** (`System.Double`) - Translation Spring Modulus for Z axis. Ignored if Z_Translation is not "Spring".
- **X_Rotation** (`Autodesk.Revit.DB.Structure.TranslationRotationValue`) - A value indicating the option for rotation about the X axis.
- **X_RotationSpringModulus** (`System.Double`) - Rotation Spring Modulus for X axis. Ignored if X_Rotation is not "Spring"

## Returns
If successful, NewLineBoundaryConditions returns an object for the newly created BoundaryConditions
with the BoundaryType = 1 - "Line". Nothing nullptr a null reference ( Nothing in Visual Basic) is returned if the operation fails.

## Remarks
This method will only function with the Autodesk Revit Structure application.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the host element does not exist in the given document.

