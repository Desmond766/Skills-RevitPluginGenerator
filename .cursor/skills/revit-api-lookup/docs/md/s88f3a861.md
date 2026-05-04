---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.DirectContext3DHandleSettings.SetTransparency(System.Int32)
source: html/26bfb243-1257-66ae-f25f-478902000415.htm
---
# Autodesk.Revit.DB.DirectContext3D.DirectContext3DHandleSettings.SetTransparency Method

Sets the transparency value of the handle and the associated DirectContext3D graphics.

## Syntax (C#)
```csharp
public void SetTransparency(
	int transparency
)
```

## Parameters
- **transparency** (`System.Int32`) - The transparency value to apply (in percentage)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The value is invalid. The valid range is 0 through 100

