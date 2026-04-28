---
kind: method
id: M:Autodesk.Revit.UI.UIDocument.GetRevitUIFamilyLoadOptions
source: html/8475fa65-390b-f227-baa8-24db9b632506.htm
---
# Autodesk.Revit.UI.UIDocument.GetRevitUIFamilyLoadOptions Method

Return the option object that allows you to use Revit's dialog boxes to let the user respond to questions that arise during loading of families.

## Syntax (C#)
```csharp
public static IFamilyLoadOptions GetRevitUIFamilyLoadOptions()
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if 
this API method is invoked in UI less mode

