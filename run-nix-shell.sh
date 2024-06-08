#!/bin/sh
. /etc/profile.d/nix.sh

nix-shell --pure --run "$@"
