---
kind: method
id: M:Autodesk.Revit.DB.Document.LoadFamily(System.String,Autodesk.Revit.DB.Family@)
zh: 文档、文件
source: html/67277d5a-0ddf-b617-c9c9-911ecb928af9.htm
---
# Autodesk.Revit.DB.Document.LoadFamily Method

**中文**: 文档、文件

Loads an entire family and all its types/symbols into the document and provides a reference
to the loaded family.

## Syntax (C#)
```csharp
public bool LoadFamily(
	string filename,
	out Family family
)
```

## Parameters
- **filename** (`System.String`) - The fully qualified filename of the Family file, usually ending in .rfa.
- **family** (`Autodesk.Revit.DB.Family %`) - A reference to the family that was loaded if successful, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Returns
True if the entire family was loaded successfully into the project, otherwise False.

## Remarks
Loading an entire family may take a considerable amount of time and memory. It is
recommended that you use one of the LoadFamilySymbol() methods
and only load those symbols that you need.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when filename is Nothing nullptr a null reference ( Nothing in Visual Basic) or empty.

