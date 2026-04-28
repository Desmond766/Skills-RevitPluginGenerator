---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.AsTextRange
source: html/a9cd63f5-8458-a362-723d-3db060d29b75.htm
---
# Autodesk.Revit.DB.FormattedText.AsTextRange Method

Returns a TextRange object that represents the entire text.

## Syntax (C#)
```csharp
public TextRange AsTextRange()
```

## Returns
The TextRange object that represents the entire text.

## Remarks
This range includes a carriage return character ('\r') that is always present.
 As a result the range can never be an empty range.

