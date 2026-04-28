---
kind: property
id: P:Autodesk.Revit.DB.RevitLinkGraphicsSettings.LinkedViewId
source: html/053b6a8c-2212-322c-8f21-b7d95e089b42.htm
---
# Autodesk.Revit.DB.RevitLinkGraphicsSettings.LinkedViewId Property

The id of the linked view associated with this RevitLinkGraphicsSettings,
 or InvalidElementId if no view is selected.
 If the LinkVisibilityType is set to
 ByLinkView , then there must be a valid LinkedViewId.

## Syntax (C#)
```csharp
public ElementId LinkedViewId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

