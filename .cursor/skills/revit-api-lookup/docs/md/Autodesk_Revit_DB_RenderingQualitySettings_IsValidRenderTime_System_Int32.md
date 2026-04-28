---
kind: method
id: M:Autodesk.Revit.DB.RenderingQualitySettings.IsValidRenderTime(System.Int32)
source: html/6e106f84-bd76-43f1-2378-9fd145f1c4db.htm
---
# Autodesk.Revit.DB.RenderingQualitySettings.IsValidRenderTime Method

Validate the render time is between 1 and 32768.

## Syntax (C#)
```csharp
public bool IsValidRenderTime(
	int value
)
```

## Parameters
- **value** (`System.Int32`) - The render time value to validate.

## Returns
True if the value is in the proper range, false otherwise.

