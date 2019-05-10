## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmarkInt.OpenComparison_FromCompareTo()
       push    rsi
       sub     rsp,20h
       mov     rsi,rcx
       mov     rcx,7FFBDE524CF0h
       mov     edx,3
       call    coreclr!coreclr_shutdown_2+0xf230
       mov     rdx,26120647348h
       mov     rdx,qword ptr [rdx]
       mov     rcx,rsi
       mov     rax,7FFBDE4471A8h
       add     rsp,20h
       pop     rsi
       jmp     rax
       add     byte ptr [rax],al
       sbb     dword ptr [00007ffc`104b5098],eax
       add     dword ptr [rax+40h],esp
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
; Total bytes of code 87
```
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmarkInt.RunOpenComparison(IComparerComparisonBenchmarks.OpenComparison`1<Int32>)
       xor     ebx,ebx
       xor     ebp,ebp
       mov     rcx,qword ptr [rsi+28h]
       cmp     dword ptr [rcx+8],0
       jle     M01_L01
M01_L00:
       mov     ecx,dword ptr [rsi+30h]
       mov     dword ptr [rsp+20h],ecx
       mov     rax,rdi
       lea     rdx,[rsp+20h]
       mov     rcx,qword ptr [rsi+28h]
       cmp     ebp,dword ptr [rcx+8]
       jae     00007ffb`de465235
       movsxd  r8,ebp
       mov     r8d,dword ptr [rcx+r8*4+10h]
       lea     rcx,[rax+8]
       mov     rcx,qword ptr [rcx]
       call    qword ptr [rax+18h]
       add     ebx,eax
       inc     ebp
       mov     rax,qword ptr [rsi+28h]
       cmp     dword ptr [rax+8],ebp
       jg      M01_L00
M01_L01:
       mov     eax,ebx
; Total bytes of code 71
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].IComparer()
       mov     rdx,qword ptr [rcx+8]
       mov     rax,7FFBDE427168h
       jmp     rax
       add     byte ptr [rax],al
       add     byte ptr [rcx],bl
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       loopne  00007ffb`de4450ae
       pop     rcx
       fdivp   st(3),st
       jg      00007ffb`de44507f
; Total bytes of code 47
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].Comparer()
       mov     rdx,qword ptr [rcx+10h]
       mov     rax,7FFBDE437170h
       jmp     rax
       add     byte ptr [rax],al
       add     byte ptr [rcx],bl
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       loopne  00007ffb`de4550ae
       pop     rdx
       fdivp   st(3),st
       jg      00007ffb`de45507f
; Total bytes of code 47
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].TComparer_TComparer()
       movsx   rdx,byte ptr [rcx+38h]
       mov     rax,7FFBDE454170h
       jmp     rax
       add     byte ptr [rax],al
       sbb     dword ptr [rax],eax
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],ch
       xor     eax,7FFBDE5Ah
       add     byte ptr [rax],al
; Total bytes of code 48
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].TComparer_IComparer()
       mov     r8,qword ptr [rcx+8]
       mov     rdx,7FFBDE5C9C10h
       mov     rax,7FFBDE484170h
       jmp     rax
       add     byte ptr [rcx],bl
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       loopne  00007ffb`de4850af
       pop     rbp
       fdivp   st(3),st
       jg      M00_L00
M00_L00:
       add     byte ptr [rdi+56h],dl
       push    rbp
       push    rbx
       sub     rsp,28h
; Total bytes of code 56
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].TComparer_Comparer()
       mov     r8,qword ptr [rcx+10h]
       mov     rdx,7FFBDE599C10h
       mov     rax,7FFBDE454170h
       jmp     rax
       add     byte ptr [rcx],bl
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       loopne  00007ffb`de4550af
       pop     rdx
       fdivp   st(3),st
       jg      M00_L00
M00_L00:
       add     byte ptr [rdi+56h],dl
       push    rbp
       push    rbx
       sub     rsp,28h
; Total bytes of code 56
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].TComparer_Comparable()
       movsx   rdx,byte ptr [rcx+40h]
       mov     rax,7FFBDE464170h
       jmp     rax
       add     byte ptr [rax],al
       sbb     dword ptr [rax],eax
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],dl
       xor     eax,7FFBDE5Bh
       add     byte ptr [rax],al
; Total bytes of code 48
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].Comparison_FromIComparer()
       mov     rdx,qword ptr [rcx+18h]
       mov     rax,7FFBDE437178h
       jmp     rax
       add     byte ptr [rax],al
       add     byte ptr [rcx],bl
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       loopne  00007ffb`de4550ae
       pop     rdx
       fdivp   st(3),st
       jg      00007ffb`de45507f
; Total bytes of code 47
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].Comparison_FromComparer()
       mov     rdx,qword ptr [rcx+20h]
       mov     rax,7FFBDE447178h
       jmp     rax
       add     byte ptr [rax],al
       add     byte ptr [rcx],bl
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       loopne  00007ffb`de4650ae
       pop     rbx
       fdivp   st(3),st
       jg      00007ffb`de46507f
; Total bytes of code 47
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].Comparison_CreateFromIComparer()
       mov     rdi,qword ptr [rsi+8]
       mov     rcx,offset System_Private_CoreLib+0xa25490
       call    coreclr!coreclr_shutdown_2+0xee30
       mov     rbx,rax
       mov     rcx,rdi
       mov     rdx,offset System_Private_CoreLib+0xa138c8
       mov     r8,offset System_Private_CoreLib+0x172038
       call    coreclr!GC_Initialize+0x679e0
       mov     rbp,rax
       lea     rcx,[rbx+8]
       mov     rdx,rdi
       call    coreclr!coreclr_shutdown_2+0xd990
       mov     rcx,rbx
       mov     rdx,rdi
       mov     r8,rbp
       call    System.Delegate.AdjustTarget(System.Object, IntPtr)
       mov     qword ptr [rbx+18h],rax
       mov     rcx,rsi
       mov     rdx,rbx
       mov     rax,7FFBDE457178h
; Total bytes of code 99
```
**No ILOffsetMap found**
System.Delegate.AdjustTarget(System.Object, IntPtr)

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].Comparison_CreateFromComparer()
       mov     rdi,qword ptr [rsi+10h]
       mov     rcx,offset System_Private_CoreLib+0xa25490
       call    coreclr!coreclr_shutdown_2+0xee30
       mov     rbx,rax
       mov     rcx,rdi
       mov     rdx,offset System_Private_CoreLib+0xa695f8
       mov     r8,offset System_Private_CoreLib+0x1fa5b0
       call    coreclr!GC_Initialize+0x679e0
       mov     rbp,rax
       test    rdi,rdi
       je      00007ffb`de4650c0
; Total bytes of code 58
```

