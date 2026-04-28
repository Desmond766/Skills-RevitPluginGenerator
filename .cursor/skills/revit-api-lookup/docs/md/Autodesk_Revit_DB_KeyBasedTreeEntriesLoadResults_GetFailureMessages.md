---
kind: method
id: M:Autodesk.Revit.DB.KeyBasedTreeEntriesLoadResults.GetFailureMessages
source: html/8bfd71ab-5066-1b94-d2ea-09af57515398.htm
---
# Autodesk.Revit.DB.KeyBasedTreeEntriesLoadResults.GetFailureMessages Method

Get all error or warnings created while attempting to load KeyBasedTreeEntries.

## Syntax (C#)
```csharp
public IList<FailureMessage> GetFailureMessages()
```

## Returns
A collection of FailureMessage objects, if any errors or warnings were encountered while
 loading and building the KeyBasedTreeEntries.

## Remarks
Revit does not post these warnings. They are provided as a convenience
 to the API user, who may wish to post them. The information in the warnings is also captured in the other error
 functions of KeyBasedTreeEntriesLoadResults.

