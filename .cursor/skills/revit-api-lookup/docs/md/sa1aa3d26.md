---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkInstance.MoveBasePointToHostBasePoint(System.Boolean)
zh: 链接模型、链接
source: html/052feb8e-e569-ddcd-30b8-a2373d1466f8.htm
---
# Autodesk.Revit.DB.RevitLinkInstance.MoveBasePointToHostBasePoint Method

**中文**: 链接模型、链接

Moves this link instance so that the base point in
 the linked document is aligned to the base point in the
 host document. This is a one-time movement and does not
 set up any shared coordinates relationship. If the rotation angle of this link instance was changed after insertion,
 the rotation angle can be preserved or reset to the original insertion angle.

## Syntax (C#)
```csharp
public void MoveBasePointToHostBasePoint(
	bool resetToOriginalRotation
)
```

## Parameters
- **resetToOriginalRotation** (`System.Boolean`) - Sets to true if: restoring the original insertion angle of the link instance after it is moved
 if there was a rotation \ mirror transform on the link instance. there was no a rotation \ mirror transform on the link instance. Sets to false to retain the current angle of the link instance after it is moved
 if there was a rotation \ mirror transform on the link instance.

## Remarks
The link must be loaded for Revit to find the location of the link's base point.
 This operation can only be performed on instances of top-level links.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RevitLinkInstance is not an instance of a loaded RevitLinkType.
 -or-
 This RevitLinkInstance is not an instance of a top-level RevitLinkType.
 -or-
 The operation is not permitted because the element is pinned.

