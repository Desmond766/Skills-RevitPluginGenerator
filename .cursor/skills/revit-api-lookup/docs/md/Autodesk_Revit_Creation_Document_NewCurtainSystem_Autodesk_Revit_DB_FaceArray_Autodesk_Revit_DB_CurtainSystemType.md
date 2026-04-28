---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewCurtainSystem(Autodesk.Revit.DB.FaceArray,Autodesk.Revit.DB.CurtainSystemType)
zh: 文档、文件
source: html/1599c7f0-c177-4fed-df96-83232424f008.htm
---
# Autodesk.Revit.Creation.Document.NewCurtainSystem Method

**中文**: 文档、文件

Creates a new CurtainSystem element from a set of faces.

## Syntax (C#)
```csharp
public CurtainSystem NewCurtainSystem(
	FaceArray faces,
	CurtainSystemType curtainSystemType
)
```

## Parameters
- **faces** (`Autodesk.Revit.DB.FaceArray`) - The faces new CurtainSystem will be created on.
- **curtainSystemType** (`Autodesk.Revit.DB.CurtainSystemType`) - The Type of CurtainSystem to be created.

## Returns
The CurtainSystem created will be returned when the operation succeeds.

## Remarks
The input faces will be copied during the operations so that they can be any
faces.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown in following cases:
The input argument faces or curtainSystemType is Nothing nullptr a null reference ( Nothing in Visual Basic) .
The size of faces is zero.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the CurtainSystem cannot be created or regenerate fails.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the curtain system type does not exist in the given document.

