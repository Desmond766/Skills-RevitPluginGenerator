---
kind: method
id: M:Autodesk.Revit.DB.Document.LoadFamilySymbol(System.String,System.String)
zh: 文档、文件
source: html/78c15d1f-7c29-29bf-7b55-e416b21cb16b.htm
---
# Autodesk.Revit.DB.Document.LoadFamilySymbol Method

**中文**: 文档、文件

Loads only a specified family type/symbol from a family file into the document.

## Syntax (C#)
```csharp
public bool LoadFamilySymbol(
	string filename,
	string name
)
```

## Parameters
- **filename** (`System.String`) - The fully qualified filename of the Family file, usually ending in .rfa.
- **name** (`System.String`) - The name of the type/symbol to be loaded, such as "W11x14".

## Returns
True if the family type/symbol was loaded successfully into the project, otherwise False.

## Remarks
This function supports loading of types/symbols stored in the family, or those available in the family Type Catalog file.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when filename or name is Nothing nullptr a null reference ( Nothing in Visual Basic) or empty.

