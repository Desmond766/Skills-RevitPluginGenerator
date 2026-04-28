---
kind: type
id: T:Autodesk.Revit.DB.SunAndShadowSettings
source: html/d616614b-a2ed-b0d0-4f11-f0a0b54a22e5.htm
---
# Autodesk.Revit.DB.SunAndShadowSettings

The SunAndShadowSettings class represents the sun control.

## Syntax (C#)
```csharp
public class SunAndShadowSettings : Element
```

## Remarks
The SunAndShadowSettings element represents the settings applied to a project or view regarding
 the position, dates, time intervals and other options for the sun control and solar studies.
 To differentiate between the project and view settings, test the ViewSpecific or OwnerViewId property.
 If the element is not view-specific this element represents a project-wide setting.
 If the element is associated to a view, this element represents a per view SunAndShadowSettings.
 When you create a new view, a new view-specific SunAndShadowSettings element is automatically created
 for it.

