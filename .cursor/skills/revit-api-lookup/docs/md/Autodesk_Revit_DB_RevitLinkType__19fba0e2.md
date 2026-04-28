---
kind: type
id: T:Autodesk.Revit.DB.RevitLinkType
source: html/2204a5ab-6476-df41-116d-23dbe3cb5407.htm
---
# Autodesk.Revit.DB.RevitLinkType

This class represents another Revit Document ("link") brought into
 the current one ("host").

## Syntax (C#)
```csharp
public class RevitLinkType : ElementType
```

## Remarks
Revit links can be nested - There can exist linked files which themselves contain
 links. A "top-level" link is one linked directly into the host, while a
 "nested" link is linked into some parent link. This can go through
 arbitrarily many layers.
Some functions give the example "A -> B -> C". This means that there is
 a host file, A, which has a top-level link, B, and a nested link C which
 has been linked into B as an attachment.

