---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewCurtainSystem2(Autodesk.Revit.DB.ReferenceArray,Autodesk.Revit.DB.CurtainSystemType)
zh: 文档、文件
source: html/e2331d61-7580-3955-56b8-566a9c990fa3.htm
---
# Autodesk.Revit.Creation.Document.NewCurtainSystem2 Method

**中文**: 文档、文件

Creates a new CurtainSystem element from a set of face references.

## Syntax (C#)
```csharp
public ICollection<ElementId> NewCurtainSystem2(
	ReferenceArray faces,
	CurtainSystemType curtainSystemType
)
```

## Parameters
- **faces** (`Autodesk.Revit.DB.ReferenceArray`) - The faces new CurtainSystem will be created on.
- **curtainSystemType** (`Autodesk.Revit.DB.CurtainSystemType`) - The Type of CurtainSystem to be created.

## Returns
A set of ElementIds of CurtainSystems will be returned when the operation succeeds.

## Remarks
The faces can belong to different masses or generic models. The number of CurtainSystems will be equal to the number of masses and generic models.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown in following cases:
The input argument faces or curtainSystemType is Nothing nullptr a null reference ( Nothing in Visual Basic) .
The size of faces is zero.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the CurtainSystem cannot be created, for example, the input faces don't 
belong to same mass or generic model. Or regenerate fails.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the curtain system type does not exist in the given document.

