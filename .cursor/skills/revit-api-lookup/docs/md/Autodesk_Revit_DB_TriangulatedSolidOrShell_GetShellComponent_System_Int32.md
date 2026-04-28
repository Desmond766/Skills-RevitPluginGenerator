---
kind: method
id: M:Autodesk.Revit.DB.TriangulatedSolidOrShell.GetShellComponent(System.Int32)
source: html/af104f01-d601-4e61-ee48-9cd75a3b1b06.htm
---
# Autodesk.Revit.DB.TriangulatedSolidOrShell.GetShellComponent Method

Returns the specified shell component of a solid or shell. Input componentIndex must lie
 between 0 and ShellComponentCount-1, inclusive. The returned TriangulatedShellComponent
 should not be modified by the caller.

## Syntax (C#)
```csharp
public TriangulatedShellComponent GetShellComponent(
	int componentIndex
)
```

## Parameters
- **componentIndex** (`System.Int32`) - The component index, must be between 0 and ShellComponentCount â€“ 1, inclusive.

## Returns
The component.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Shell component index componentIndex is out of range.

