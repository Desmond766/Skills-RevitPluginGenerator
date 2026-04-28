---
kind: method
id: M:Autodesk.Revit.DB.Document.LoadFamily(System.String)
zh: 文档、文件
source: html/3fefb883-07ab-e638-edf9-9c8b8f00c0f0.htm
---
# Autodesk.Revit.DB.Document.LoadFamily Method

**中文**: 文档、文件

Loads an entire family and all its types/symbols into the document.

## Syntax (C#)
```csharp
public bool LoadFamily(
	string filename
)
```

## Parameters
- **filename** (`System.String`) - The fully qualified filename of the Family file, usually ending in .rfa.

## Returns
True if the entire family was loaded successfully into the project, otherwise False.

## Remarks
Loading an entire family may take a considerable amount of time and memory. It is
recommended that you use one of the LoadFamilySymbol() methods
and only load those symbols that you need.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when filename is Nothing nullptr a null reference ( Nothing in Visual Basic) or empty.

