---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionType.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Structure.StructuralConnectionApplyTo,System.String,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/9d198a3e-fe9b-c094-4f5e-cf061382ff3f.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionType.Create Method

**中文**: 创建、新建、生成、建立、新增

Create a new StructuralConnectionType, allowing the specified
 annotation FamilySymbol to be applied to structural members.

## Syntax (C#)
```csharp
public static StructuralConnectionType Create(
	Document doc,
	StructuralConnectionApplyTo applyTo,
	string name,
	ElementId familySymbolId
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`)
- **applyTo** (`Autodesk.Revit.DB.Structure.StructuralConnectionApplyTo`) - Specify which type of member this connection type can be applied to.
- **name** (`System.String`) - A name for the connection type. It must be unique within the document.
- **familySymbolId** (`Autodesk.Revit.DB.ElementId`) - The id of an annotation FamilySymbol. InvalidElementId is
 allowed. Otherwise, the FamilySymbol must
 be in the category "Connection Symbols"
 (OST_StructConnectionSymbols) and have its "Apply
 To" parameter set to match the applyTo argument.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - familySymbolId is the id of some element that is not a
 FamilySymbol, is not of the category "Connection
 Symbols" (OST_StructConnectionSymbols), or has its "Apply
 To" parameter not equal to applyTo.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

