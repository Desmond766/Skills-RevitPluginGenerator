---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.WriteJournalComment(System.String,System.Boolean)
source: html/97ec1eca-ab92-1cee-fdda-7bf3ce91c504.htm
---
# Autodesk.Revit.ApplicationServices.Application.WriteJournalComment Method

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

