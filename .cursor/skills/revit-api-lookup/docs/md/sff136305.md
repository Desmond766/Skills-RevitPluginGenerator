---
kind: property
id: P:Autodesk.Revit.UI.RibbonItem.ItemText
source: html/37aa82da-384b-c258-b694-6e4ee03bdcb0.htm
---
# Autodesk.Revit.UI.RibbonItem.ItemText Property

Gets or sets the text displayed on the item.

## Syntax (C#)
```csharp
public virtual string ItemText { get; set; }
```

## Remarks
The text can be changed at run time. Nothing nullptr a null reference ( Nothing in Visual Basic) or empty string is not allowed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when setting the text to empty or to the string contains "%".
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when setting the text to Nothing nullptr a null reference ( Nothing in Visual Basic) .

