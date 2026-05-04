---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.GetSuperscriptStatus
source: html/3c2fe0d9-3c34-077a-63da-6549bbeaf852.htm
---
# Autodesk.Revit.DB.FormattedText.GetSuperscriptStatus Method

Returns whether All , None or a Mixed of characters in the entire text are superscripted.

## Syntax (C#)
```csharp
public FormatStatus GetSuperscriptStatus()
```

## Returns
The format status of superscript on characters FormatStatus .

## Remarks
This function only returns All or None if the entire text contains one character.

