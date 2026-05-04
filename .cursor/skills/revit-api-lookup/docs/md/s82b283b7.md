---
kind: method
id: M:Autodesk.Revit.DB.FillPatternElement.SetFillPattern(Autodesk.Revit.DB.FillPattern)
source: html/86b24b5b-ef47-65e4-8661-bbb62f26a96f.htm
---
# Autodesk.Revit.DB.FillPatternElement.SetFillPattern Method

Sets the FillPattern associated to this element.

## Syntax (C#)
```csharp
public void SetFillPattern(
	FillPattern newFillPattern
)
```

## Parameters
- **newFillPattern** (`Autodesk.Revit.DB.FillPattern`) - The new FillPattern object.

## Remarks
The data stored inside the input FillPattern will be copied into this element.
 The input FillPattern itself will not be associated with the element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - newFillPattern does not have a valid Target.
 -or-
 newFillPattern does not have a valid Name.
 -or-
 newFillPattern is a solid fill pattern.
 -or-
 newFillPattern contains FillGrids with a zero Offset.
 -or-
 The name of the newFillPattern already exists.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element is the build-in solid fill pattern element and can not be modified.

