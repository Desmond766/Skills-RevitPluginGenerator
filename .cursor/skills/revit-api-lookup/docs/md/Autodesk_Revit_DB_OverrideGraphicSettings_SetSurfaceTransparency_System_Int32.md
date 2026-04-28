---
kind: method
id: M:Autodesk.Revit.DB.OverrideGraphicSettings.SetSurfaceTransparency(System.Int32)
source: html/a8803ede-cdc0-31ff-113b-9a3a3b6befe6.htm
---
# Autodesk.Revit.DB.OverrideGraphicSettings.SetSurfaceTransparency Method

Sets the projection surface transparency.

## Syntax (C#)
```csharp
public OverrideGraphicSettings SetSurfaceTransparency(
	int transparency
)
```

## Parameters
- **transparency** (`System.Int32`) - Value of the transparency of the projection surface (0 = opaque, 100 = fully transparent).

## Returns
Reference to the changed object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Transparency must be greater than 0 and less than 100.

