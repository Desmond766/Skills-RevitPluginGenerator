---
kind: property
id: P:Autodesk.Revit.UI.TextBox.Value
source: html/882e5d26-e7c0-e0ee-092b-9c376f333d4b.htm
---
# Autodesk.Revit.UI.TextBox.Value Property

The object that supplies the text value.

## Syntax (C#)
```csharp
public Object Value { get; set; }
```

## Remarks
The value assigned to the TextBox can be a String or any other data type. 
If the type is not a String the TextBox will display the return of the ToString() method. 
When the text is edited in the UI, the type of Value will always be String .

