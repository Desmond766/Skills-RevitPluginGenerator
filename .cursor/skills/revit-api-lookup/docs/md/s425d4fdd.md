---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.IsNotLoadedIntoMultipleOpenDocuments
source: html/7e675de0-ce86-ef2e-fdef-f5e12558684d.htm
---
# Autodesk.Revit.DB.RevitLinkType.IsNotLoadedIntoMultipleOpenDocuments Method

Checks whether the link is loaded into more than one open document
 in this session of Revit. If the link is loaded into multiple open
 documents, reload will be disabled.

## Syntax (C#)
```csharp
public bool IsNotLoadedIntoMultipleOpenDocuments()
```

## Returns
True if the link is loaded into at most one open document. False if the link
 is loaded into more than one open document.

## Remarks
Revit can open several documents which contain the same link. If
 this is the case, Revit cannot reload the link, as doing
 so would make changes to a non-active document. You will need to close
 one or more documents in order to modify the link. If the link is loaded into multiple documents across multiple sessions
 of Revit, this function will return true. We only check the current session
 of Revit. It is safe to reload a link which is loaded into multiple
 sessions, as long as it is not loaded into more than one document
 in any one session. If this function returns true, it is safe to reload the link.

