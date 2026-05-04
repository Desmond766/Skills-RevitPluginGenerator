---
kind: method
id: M:Autodesk.Revit.DB.Document.LoadFamily(System.String,Autodesk.Revit.DB.IFamilyLoadOptions,Autodesk.Revit.DB.Family@)
zh: 文档、文件
source: html/5d34b8dd-9137-da2f-9df7-172304d0cc08.htm
---
# Autodesk.Revit.DB.Document.LoadFamily Method

**中文**: 文档、文件

Loads an entire family and all its types/symbols into the document and provides a reference
to the loaded family.

## Syntax (C#)
```csharp
public bool LoadFamily(
	string filename,
	IFamilyLoadOptions familyLoadOptions,
	out Family family
)
```

## Parameters
- **filename** (`System.String`) - The fully qualified filename of the Family file, usually ending in .rfa.
- **familyLoadOptions** (`Autodesk.Revit.DB.IFamilyLoadOptions`) - The interface implementation to use when loading a family into the document.
- **family** (`Autodesk.Revit.DB.Family %`) - A reference to the family that was loaded if successful, otherwise Nothing.

## Returns
True if the entire family was loaded successfully into the project, otherwise False.

## Remarks
Loading an entire family may take a considerable amount of time and memory. It is
recommended that you use one of the LoadFamilySymbol() methods
and only load those symbols that you need.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when filename is Nothing nullptr a null reference ( Nothing in Visual Basic) or empty.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument "familyLoadOptions" is Nothing nullptr a null reference ( Nothing in Visual Basic) .

