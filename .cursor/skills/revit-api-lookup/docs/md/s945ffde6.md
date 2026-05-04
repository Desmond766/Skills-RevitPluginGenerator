---
kind: method
id: M:Autodesk.Revit.DB.Document.LoadFamilySymbol(System.String,System.String,Autodesk.Revit.DB.FamilySymbol@)
zh: 文档、文件
source: html/ba726add-04f7-7757-6557-4e32e8b1008b.htm
---
# Autodesk.Revit.DB.Document.LoadFamilySymbol Method

**中文**: 文档、文件

Loads only the specified family type/symbol from a family file into the document and
provides a reference to the loaded family symbol.

## Syntax (C#)
```csharp
public bool LoadFamilySymbol(
	string filename,
	string name,
	out FamilySymbol symbol
)
```

## Parameters
- **filename** (`System.String`) - The fully qualified filename of the Family file, usually ending in .rfa.
- **name** (`System.String`) - The name of the type/symbol to be loaded, such as "W11x14".
- **symbol** (`Autodesk.Revit.DB.FamilySymbol %`) - A reference to the family symbol that was loaded if successful, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Returns
True if the family type/symbol was loaded successfully into the project, otherwise False.

## Remarks
This function supports loading of types/symbols stored in the family, or those available in the family Type Catalog file.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when filename or name is Nothing nullptr a null reference ( Nothing in Visual Basic) or empty.

