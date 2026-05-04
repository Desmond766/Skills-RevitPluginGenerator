---
kind: type
id: T:Autodesk.Revit.DB.ColumnAttachment
source: html/848a6cb6-c6cf-584c-eb24-5a91b9d3261d.htm
---
# Autodesk.Revit.DB.ColumnAttachment

An object representing the attachment of the top or bottom of a column to some target:
 a floor, roof, ceiling, beam, or brace.

## Syntax (C#)
```csharp
public class ColumnAttachment : IDisposable
```

## Remarks
Call IsValidColumn() and IsValidTarget() to verify that specific elements support
 column attachments. A column has at most one top attachment and one bottom
 attachment.

