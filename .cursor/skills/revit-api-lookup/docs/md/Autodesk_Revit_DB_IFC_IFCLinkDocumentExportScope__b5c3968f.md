---
kind: type
id: T:Autodesk.Revit.DB.IFC.IFCLinkDocumentExportScope
source: html/60ae5791-59a1-79c6-b2e6-e3e235b936b5.htm
---
# Autodesk.Revit.DB.IFC.IFCLinkDocumentExportScope

A class that allows for the export of one linked document to IFC.

## Syntax (C#)
```csharp
public class IFCLinkDocumentExportScope : IDisposable
```

## Remarks
Linked documents can only be exported within a transaction, but it is illegal to start
 a transaction for a linked document. This gives a special exception that does the
 work necessary to make sure that the host documents do not end up in unstable states
 after the export. This is not guaranteed for any other workflow.
 To ensure that the lifetime of the object is correctly managed, you should declare an instance
 of this class as a part of a 'using' statement in C# or similar construct in other lanuguages.

