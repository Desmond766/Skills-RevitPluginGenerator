---
kind: property
id: P:Autodesk.Revit.UI.RibbonItem.Enabled
source: html/1e8498e5-1609-cf26-fb58-012e73db9f5b.htm
---
# Autodesk.Revit.UI.RibbonItem.Enabled Property

Gets or sets a value indicating whether the item is enabled.

## Syntax (C#)
```csharp
public bool Enabled { get; set; }
```

## Remarks
When the Enabled property is set to false, the item cannot be clicked, 
and the item's appearance changes. The Image and Text assigned to the item appear grayed
out. For pushbuttons, the button may be enabled programmatically but be disabled in the user interface
because of the Revit context; see the property IsEnabledByContext for RibbonButton.

