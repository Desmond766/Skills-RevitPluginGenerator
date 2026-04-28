---
kind: method
id: M:Autodesk.Revit.DB.LinePatternElement.SetLinePattern(Autodesk.Revit.DB.LinePattern)
source: html/b57a0bf6-8e27-1f58-8441-c8aee20f9073.htm
---
# Autodesk.Revit.DB.LinePatternElement.SetLinePattern Method

Sets the LinePattern associated to this element.

## Syntax (C#)
```csharp
public void SetLinePattern(
	LinePattern newLinePattern
)
```

## Parameters
- **newLinePattern** (`Autodesk.Revit.DB.LinePattern`) - The new LinePattern object.

## Remarks
The data stored inside the input LinePattern will be copied into this element.
 The input LinePattern itself will not be associated with the element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The Line Pattern is not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

