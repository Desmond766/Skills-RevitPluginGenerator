---
kind: method
id: M:Autodesk.Revit.DB.SlabShapeEditor.CreateCreasesFromFoldingLines(Autodesk.Revit.DB.Element,System.Collections.Generic.IList{Autodesk.Revit.DB.Reference})
source: html/8adabb8c-e774-67c3-36a9-340cb8f0ab3f.htm
---
# Autodesk.Revit.DB.SlabShapeEditor.CreateCreasesFromFoldingLines Method

Convert selected folding lines to split lines

## Syntax (C#)
```csharp
public void CreateCreasesFromFoldingLines(
	Element hostObj,
	IList<Reference> references
)
```

## Parameters
- **hostObj** (`Autodesk.Revit.DB.Element`) - object that hosts the SlabShapeEditor
- **references** (`System.Collections.Generic.IList < Reference >`) - References of selected folding lines.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - this operation failed.

