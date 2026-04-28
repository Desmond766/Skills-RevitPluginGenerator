---
kind: property
id: P:Autodesk.Revit.DB.RevitLinkGraphicsSettings.LinkVisibilityType
source: html/e48416ed-38f3-063d-cddd-8262486772b6.htm
---
# Autodesk.Revit.DB.RevitLinkGraphicsSettings.LinkVisibilityType Property

The visibility type of RevitLinkGraphicsSettings.
 If the type is set to ByHostView or
 ByLinkView , then the dependent properties
 of RevitLinkGraphicsSettings will be reset to their default state. The state of dependent properties can be changed later.

## Syntax (C#)
```csharp
public LinkVisibility LinkVisibilityType { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

