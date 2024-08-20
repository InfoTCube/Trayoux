<script lang="ts">
    export let data: { balance: number };
</script>

<div class="max-w-sm m-5 p-6 bg-white border border-gray-200 rounded-lg shadow dark:bg-gray-800 dark:border-gray-700">
    <div class="flex text-white">
        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="size-10 mr-1 mt-0.5">
            <path stroke-linecap="round" stroke-linejoin="round" d="M12 6v12m-3-2.818.879.659c1.171.879 3.07.879 4.242 0 1.172-.879 1.172-2.303 0-3.182C13.536 12.219 12.768 12 12 12c-.725 0-1.45-.22-2.003-.659-1.106-.879-1.106-2.303 0-3.182s2.9-.879 4.006 0l.415.33M21 12a9 9 0 1 1-18 0 9 9 0 0 1 18 0Z" />
          </svg>      
        <h1 class="text-4xl flex">
            Balance:
            {#if data.balance >= 0}
                <p class="ml-2 text-bold text-green-500">{data.balance}</p>
            {:else}
                <p class="ml-2 text-bold text-red-500">{data.balance}</p>
            {/if}

        </h1>
    </div>
</div>
