---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewAreaBoundaryConditions(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Structure.TranslationRotationValue,System.Double,Autodesk.Revit.DB.Structure.TranslationRotationValue,System.Double,Autodesk.Revit.DB.Structure.TranslationRotationValue,System.Double)
zh: 文档、文件
source: html/e75ba4d7-f2e6-e5c1-d695-ef6476a19711.htm
---
# Autodesk.Revit.Creation.Document.NewAreaBoundaryConditions Method

**中文**: 文档、文件

Creates a new Area BoundaryConditions element on a host element.

## Syntax (C#)
```csharp
public BoundaryConditions NewAreaBoundaryConditions(
	Element hostElement,
	TranslationRotationValue X_Translation,
	double X_TranslationSpringModulus,
	TranslationRotationValue Y_Translation,
	double Y_TranslationSpringModulus,
	TranslationRotationValue Z_Translation,
	double Z_TranslationSpringModulus
)
```

## Parameters
- **hostElement** (`Autodesk.Revit.DB.Element`) - A Wall, Slab or Slab Foundation to host the boundary conditions.
- **X_Translation** (`Autodesk.Revit.DB.Structure.TranslationRotationValue`) - A value indicating the X axis translation option.
- **X_TranslationSpringModulus** (`System.Double`) - Translation Spring Modulus for X axis. Ignored if X_Translation is not "Spring".
- **Y_Translation** (`Autodesk.Revit.DB.Structure.TranslationRotationValue`) - A value indicating the Y axis translation option.
- **Y_TranslationSpringModulus** (`System.Double`) - Translation Spring Modulus for Y axis. Ignored if Y_Translation is not "Spring".
- **Z_Translation** (`Autodesk.Revit.DB.Structure.TranslationRotationValue`) - A value indicating the Z axis translation option.
- **Z_TranslationSpringModulus** (`System.Double`) - Translation Spring Modulus for Z axis. Ignored if Z_Translation is not "Spring".

## Returns
If successful, NewAreaBoundaryConditions returns an object for the newly created BoundaryConditions
with the BoundaryType = 2 - "Area". Nothing nullptr a null reference ( Nothing in Visual Basic) is returned if the operation fails.

## Remarks
This method will only function with the Autodesk Revit Structure application.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the host element does not exist in the given document.

