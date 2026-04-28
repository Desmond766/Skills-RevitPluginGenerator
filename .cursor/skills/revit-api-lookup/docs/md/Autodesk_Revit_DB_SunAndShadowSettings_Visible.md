---
kind: property
id: P:Autodesk.Revit.DB.SunAndShadowSettings.Visible
source: html/453465ac-2b3a-b6a1-ce46-5c860da3b6a3.htm
---
# Autodesk.Revit.DB.SunAndShadowSettings.Visible Property

Visibility in current view for a per-view SunAndShadowSettings element.

## Syntax (C#)
```csharp
public bool Visible { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element is not view specific (in which case visibility
 is not relevant) or if internally its view is not accessible.

