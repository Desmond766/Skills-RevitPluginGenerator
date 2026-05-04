---
kind: property
id: P:Autodesk.Revit.UI.RibbonPanel.Title
zh: 功能区
source: html/3872fc86-a3c1-e20d-81d2-307b4e303152.htm
---
# Autodesk.Revit.UI.RibbonPanel.Title Property

**中文**: 功能区

Gets or sets the text of the RibbonPanel.

## Syntax (C#)
```csharp
public string Title { get; set; }
```

## Remarks
If this property is not set, the default value is its Name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the title contains angle bracket.

