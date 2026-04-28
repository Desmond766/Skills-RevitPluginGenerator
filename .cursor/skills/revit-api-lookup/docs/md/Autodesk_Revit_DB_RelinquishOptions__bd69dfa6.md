---
kind: type
id: T:Autodesk.Revit.DB.RelinquishOptions
source: html/af30374c-7e99-d52e-f648-c5969e91e9d8.htm
---
# Autodesk.Revit.DB.RelinquishOptions

Options to control behavior of relinquishing ownership of elements and worksets.

## Syntax (C#)
```csharp
public class RelinquishOptions : IDisposable
```

## Remarks
The settings correspond to the checkboxes in the Synchronize with Central dialog
 in the section "After synchronizing, relinquish the following worksets and elements:". An element can be owned (reflected in the "Edited By" parameter) either
 by being checked out ("borrowed") or by belonging to a checked out workset. Relinquishing a workset will relinquish all its unmodified elements that the current user owns. The subtle interactions between checking out elements and checking out worksets
 are beyond the scope of the documentation for this class. But as an example,
 if a wall is borrowed (explicitly checked out) and then its workset is checked out,
 then the wall is no longer considered borrowed because the workset ownership
 implicitly grants ownership of all elements in the workset (except elements borrowed by other users).

