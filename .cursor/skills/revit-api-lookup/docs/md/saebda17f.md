---
kind: type
id: T:Autodesk.Revit.DB.DocumentDifference
source: html/856189a3-0160-8609-8e6b-df23ea369e43.htm
---
# Autodesk.Revit.DB.DocumentDifference

DocumentDifference represents the difference (including added elements, modified elements and deleted elements) of a Revit model between different DocumentVersion of the model.

## Syntax (C#)
```csharp
public class DocumentDifference : IDisposable
```

## Remarks
For workshared models, DocumentDifference may contain all the added elements, modified elements and deleted elements.
 For non-workshared models, deleted elements are not tracked, so this object may only contain added elements and modified elements.

