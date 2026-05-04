---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.GetSubscriptStatus
source: html/05b66803-bb4a-4d59-b3c2-c69d5932cadd.htm
---
# Autodesk.Revit.DB.FormattedText.GetSubscriptStatus Method

Returns whether All , None or a Mixed of characters in the entire text are subscripted.

## Syntax (C#)
```csharp
public FormatStatus GetSubscriptStatus()
```

## Returns
The format status of subscript on characters FormatStatus .

## Remarks
This function only returns All or None if the entire text contains one character.

