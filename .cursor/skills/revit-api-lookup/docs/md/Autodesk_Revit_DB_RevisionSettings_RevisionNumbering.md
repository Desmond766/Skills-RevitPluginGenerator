---
kind: property
id: P:Autodesk.Revit.DB.RevisionSettings.RevisionNumbering
source: html/b9ba5975-0cb1-c724-e624-8495c49a6999.htm
---
# Autodesk.Revit.DB.RevisionSettings.RevisionNumbering Property

Determines how the revision number values will display on sheets.

## Syntax (C#)
```csharp
public RevisionNumbering RevisionNumbering { get; set; }
```

## Remarks
When revision clouds appear on a sheet, the revision number of each revision can be displayed either by
 tagging the revision cloud or by a revision schedule within the sheet's titleblock. There
 are two ways the number can be determined:
 Per project: The value of the Revision numbers will always correspond to the project-wide Revision Sequence Number
 assigned to the revision. For example, if revision clouds for revisions with sequence numbers 5, 7, and 8 are
 placed on a sheet then revision tags and schedules on that sheet would display 5, 7, and 8. Per sheet: Revision numbers will be assigned consecutive numbers based on the revision clouds
 visible on that sheet. For example, if revision clouds for revisions assigned project-wide Revision Sequence Numbers 5, 7, and 8 are
 placed on a sheet then revision tags and schedules on that sheet would display 1, 2, and 3.
 The sequence on the sheet will still follow the relative ordering of the Revision Sequence Numbers,
 so in this example revision 5 would be displayed as 1 on the sheet, revision 7 would be
 displayed as 2, etc. Note that changing this setting may change the numbering of revisions on any existing
 sheets. The numbering will be changed even for revisions that are already issued.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

