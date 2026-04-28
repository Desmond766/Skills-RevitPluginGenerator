---
kind: method
id: M:Autodesk.Revit.DB.Document.Regenerate
zh: 文档、文件
source: html/22468e2c-9772-8478-0816-c9759aa43428.htm
---
# Autodesk.Revit.DB.Document.Regenerate Method

**中文**: 文档、文件

Updates the elements in the Revit document to reflect all changes.

## Syntax (C#)
```csharp
public void Regenerate()
```

## Remarks
Use this method to force update to the document after a group of changes. Note that when a transaction is committed 
there is an automatic call to regenerate the document.

## Exceptions
- **Autodesk.Revit.Exceptions.RegenerationFailedException** - Thrown when the operation fails.
 If regeneration fails, there is posted error of severity DocumentCorruption that will be delivered to the end user 
at the end of transaction explaining what specifically has happened. If regeneration has failed, document is corrupted and even reading from it is illegal. Code that called regeneration and got this exception should not catch and ignore it - instead, it should do nothing 
but internal cleanup and return control to the owner of currently active transaction/subtransaction, which must be aborted.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Modification of the document is forbidden. Typically, 
this is because there is no open transaction; consult documentation for Document.IsModified for other possible causes.

