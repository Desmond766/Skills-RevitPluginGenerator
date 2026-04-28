---
kind: type
id: T:Autodesk.Revit.DB.DocumentVersion
source: html/3574fa56-016e-b146-1499-b3b1c9129705.htm
---
# Autodesk.Revit.DB.DocumentVersion

This class uniquely identifies an edition of a given document.

## Syntax (C#)
```csharp
public class DocumentVersion : IDisposable
```

## Remarks
DocumentVersion consists
 of two parts - a GUID and an integer. The GUID is updated as new elements
 are created in the document, but it is not necessarily changed whenever
 any individual change is made to the document. The integer is updated when
 the document is saved. The GUID will change as changes are made to a model, so it should not be treated
 as a static value. This class does not contain any time information - you cannot compare two
 DocumentVersions and know which document is newer. It can be used
 to tell whether a document has changed since it was last inspected.
 See [!:Autodesk::Revit::DB::BasicFileInfo::GetDocumentVersion()]

