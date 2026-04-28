---
kind: property
id: P:Autodesk.Revit.DB.RevitLinkType.AttachmentType
source: html/456da4bd-16ef-a039-9934-2644f84fdb3b.htm
---
# Autodesk.Revit.DB.RevitLinkType.AttachmentType Property

The attachment/overlay status of this link.

## Syntax (C#)
```csharp
public AttachmentType AttachmentType { get; set; }
```

## Remarks
"Attachment" links are considered to be part of their parent
 link and will be brought along if their parent is linked into
 another document. "Overlay" links are only visible when their
 parent is open directly. 
 For example: A user has a file B which contains a link C, and
 they wish to link B into another file, A. If C is an overlay, C
 will not be loaded into A. If C is an attachment, then C will
 be loaded into A along with B.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This RevitLinkType is not a top-level link.

