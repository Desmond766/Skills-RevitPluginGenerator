---
kind: method
id: M:Autodesk.Revit.ApplicationServices.ControlledApplication.WriteJournalComment(System.String,System.Boolean)
source: html/9b5534bb-57f9-ec1e-c67d-fe507df28742.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.WriteJournalComment Method

Writes a comment to the Revit journal file.

## Syntax (C#)
```csharp
public void WriteJournalComment(
	string comment,
	bool timeStamp
)
```

## Parameters
- **comment** (`System.String`) - Text for journal comment.
- **timeStamp** (`System.Boolean`) - If a time stamp should be included in the journal comment.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

