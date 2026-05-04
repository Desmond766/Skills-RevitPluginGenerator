---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkInstance.MoveOriginToHostOrigin(System.Boolean)
zh: 链接模型、链接
source: html/2ebcfd4d-c7a4-7694-a06b-372c3675cec9.htm
---
# Autodesk.Revit.DB.RevitLinkInstance.MoveOriginToHostOrigin Method

**中文**: 链接模型、链接

Moves this link instance so that the internal origin
 of the linked document is aligned to the internal origin
 of the host document. This is a one-time movement and does not
 set up any shared coordinates relationship. If the rotation angle of the link instance was changed after insertion,
 the rotation angle can be preserved or reset to the original insertion angle.

## Syntax (C#)
```csharp
public void MoveOriginToHostOrigin(
	bool resetToOriginalRotation
)
```

## Parameters
- **resetToOriginalRotation** (`System.Boolean`) - Sets to true if: restoring the original insertion angle of the link instance after it is moved
 if there was a rotation \ mirror transform on the link instance. there was no a rotation \ mirror transform on the link instance. Sets to false to retain the current angle of the link instance after it is moved
 if there was a rotation \ mirror transform on the link instance.

## Remarks
This operation can only be performed on instances of top-level links.
 The internal origin is not necessarily the same location as the Project
 Base Point. See MoveBasePointToHostBasePoint(Boolean) .

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RevitLinkInstance is not an instance of a loaded RevitLinkType.
 -or-
 This RevitLinkInstance is not an instance of a top-level RevitLinkType.
 -or-
 The operation is not permitted because the element is pinned.

