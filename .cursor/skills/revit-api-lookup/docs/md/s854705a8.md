---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.GetPlainText
source: html/86974db8-8f2a-354f-f7f7-99542cbdff76.htm
---
# Autodesk.Revit.DB.FormattedText.GetPlainText Method

Returns the entire text in a plain text form.

## Syntax (C#)
```csharp
public string GetPlainText()
```

## Returns
The entire text in a plain text form.

## Remarks
The text includes a carriage return character ('\r') that is always present.
 As a result this method will never return an empty string.

