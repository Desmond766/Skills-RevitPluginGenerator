---
kind: property
id: P:Autodesk.Revit.DB.Revision.RevisionNumber
source: html/f46d2d49-1d37-6e99-f450-d21401fd848f.htm
---
# Autodesk.Revit.DB.Revision.RevisionNumber Property

The Revision number of this revision.

## Syntax (C#)
```csharp
public string RevisionNumber { get; }
```

## Remarks
Note that this field is only available if the RevisionSettings are set to number revisions PerProject.
 When Revisions are numbered PerSheet, a given Revision may display a different RevisionNumber on each sheet.
 In this case, the revision number can be obtained by calling [!:Autodesk::Revit::DB::ViewSheet::GetRevisionNumberOnSheet()] .

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is not valid for when the revision numbering is per sheet.

